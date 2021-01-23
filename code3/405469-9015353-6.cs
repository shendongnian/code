    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using MbUnit.Framework;
    using Moq;
    
    [TestFixture]
    public class IDisposableTests
    {
        [Test]
        public void ThrowsObjectDisposedExceptions()
        {
            var assemblyToTest = Assembly.LoadWithPartialName("MyAssembly");
    
            // Get all types that implement IDisposable
            var disposableTypes = 
                from type in assemblyToTest.GetTypes()
                where type.GetInterface(typeof(IDisposable).FullName) != null
                select type;
    
            foreach (var type in disposableTypes)
            {
                // Try to get default constructor first...
                var constructor = type.GetConstructor(Type.EmptyTypes);
    
                if (constructor == null)
                {
                    // Otherwise get first parameter based constructor...
                    var constructors = type.GetConstructors();
    
                    if (constructors != null &&
                        constructors.Length > 0)
                    {
                        constructor = constructors[0];
                    }
                }
    
                // If there is a public constructor...
                if (constructor != null)
                {
                    object instance = Activator.CreateInstance(type, GetDefaultArguments(constructor));
    
                    (instance as IDisposable).Dispose();
    
                    foreach (var method in type.GetMethods())
                    {
                        if (!this.IsExcluded(method))
                        {
                            bool threwObjectDisposedException = false;
    
                            try
                            {
                                method.Invoke(instance, GetDefaultArguments(method));
                            }
                            catch (TargetInvocationException ex)
                            {
                                if (ex.InnerException.GetType() == typeof(ObjectDisposedException))
                                {
                                    threwObjectDisposedException = true;
                                }
                            }
    
                            Assert.IsTrue(threwObjectDisposedException);
                        }
                    }
                }
            }
        }
    
        private bool IsExcluded(MethodInfo method)
        {
            // May want to include ToString, GetHashCode.
            // Doesn't handle checking overloads which would take more
            // logic to compare parameters etc.
            if (method.Name == "Dispose" ||
                method.Name == "GetType")
            {
                return true;
            }
    
            return false;
        }
    
        private object[] GetDefaultArguments(MethodBase method)
        {
            var arguments = new List<object>();
            
            foreach (var parameter in method.GetParameters())
            {
                var type = parameter.ParameterType;
    
                if (type.IsValueType)
                {
                    arguments.Add(Activator.CreateInstance(type));
                }
                else if (!type.IsSealed)
                {
                    dynamic mock = Activator.CreateInstance(typeof(Mock<>).MakeGenericType(type));
                    arguments.Add(mock.Object);
                }
                else
                {
                    arguments.Add(null);
                }
            }
    
            return arguments.ToArray();
        }
    }
