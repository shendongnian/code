    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Dynamic;
    using System.IO;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using Microsoft.Win32;
    using System.Diagnostics;
    class DynamicCOMObject : IDynamicMetaObjectProvider, IDisposable 
    {
        private Type m_comType = null;
        private object m_comHolder = null;
        public DynamicCOMObject(string progId)
        {        
            m_comType = Type.GetTypeFromProgID(progId);
            m_comHolder = Activator.CreateInstance(m_comType);
        }
        public void Dispose()
        {
            if (m_comHolder != null)
            {
                Marshal.ReleaseComObject(m_comHolder);
                m_comHolder = null;
            }
        }
        #region IDynamicMetaObjectProvider Members
        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(
            System.Linq.Expressions.Expression parameter)
        {
            return new DynamicCOMObjectMetaObject(parameter, this);
        }
        #endregion
        private class DynamicCOMObjectMetaObject : DynamicMetaObject
        {
            internal DynamicCOMObjectMetaObject(
                System.Linq.Expressions.Expression parameter,
                DynamicCOMObject value)
                : base(parameter, BindingRestrictions.Empty, value)
            {
            }
            public override DynamicMetaObject BindSetMember(SetMemberBinder binder,
                DynamicMetaObject value)
            {
                // Method to call in the containing class:
                string methodName = "SetValue";
                // setup the binding restrictions.
                BindingRestrictions restrictions =
                    BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                // setup the parameters:
                Expression[] args = new Expression[2];
                // First parameter is the name of the property to Set
                args[0] = Expression.Constant(binder.Name);
                // Second parameter is the value
                args[1] = Expression.Convert(value.Expression, typeof(object));
                // Setup the 'this' reference
                Expression self = Expression.Convert(Expression, LimitType);
                // Setup the method call expression
                Expression methodCall = Expression.Call(self,
                        typeof(DynamicCOMObject).GetMethod(methodName),
                        args);
                // Create a meta object to invoke Set later:
                DynamicMetaObject setDictionaryEntry = new DynamicMetaObject(
                    methodCall,
                    restrictions);
                // return that dynamic object
                return setDictionaryEntry;
            }
            public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
            {
                // Method call in the containing class:
                string methodName = "GetValue";
                // One parameter
                Expression[] parameters = new Expression[]
                {                
                    Expression.Constant(binder.Name)
                };
                DynamicMetaObject getDictionaryEntry = new DynamicMetaObject(
                    Expression.Call(
                        Expression.Convert(Expression, LimitType),
                        typeof(DynamicCOMObject).GetMethod(methodName),
                        parameters),
                    BindingRestrictions.GetTypeRestriction(Expression, LimitType));
                return getDictionaryEntry;
            }
            public override DynamicMetaObject BindInvokeMember(
                InvokeMemberBinder binder, DynamicMetaObject[] args)
            {
                Expression[] parameters = new Expression[2];
                Expression[] subs = new Expression[args.Length];
                parameters[0] = Expression.Constant(binder.Name);
                for (int i = 0; i < args.Length; i++)
                    subs[i] = args[i].Expression;
                
                parameters[1] = Expression.NewArrayInit(typeof(object), subs);
                
                DynamicMetaObject methodInfo = new DynamicMetaObject(
                    Expression.Call(
                    Expression.Convert(Expression, LimitType),
                    typeof(DynamicCOMObject).GetMethod("CallMethod"),
                    parameters),
                    BindingRestrictions.GetTypeRestriction(Expression, LimitType));
                return methodInfo;
            }
        }
        public object SetValue(string key, object value)
        {
            return m_comType.InvokeMember(key,
                BindingFlags.Instance | BindingFlags.SetProperty | BindingFlags.Public,
                null,
                m_comHolder,
                new object[] { value });   
        }
        public object GetValue(string key)
        {
            return m_comType.InvokeMember(key,
                BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.Public,
                null,
                m_comHolder,
                null);          
        }
        public object CallMethod(string methodName, params object[] parameters)
        {
            return m_comType.InvokeMember(methodName,
                BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.Public,
                null,
                m_comHolder,
                parameters);        
        }
    }
