      comboBox1.ValueMember = GetPropName(() => ObjectForListObject.ObjectID);
    
      public static string GetPropName<T>(Expression<Func<T>> propExp)
      {
         return (propExp.Body as MemberExpression).Member.Name;
      }
