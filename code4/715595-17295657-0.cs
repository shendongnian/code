    public object[] LoadIt(KeyValuePair<Type,string>[] resources, ContentManager content)
    {
        object[] result = new object[resources.Length];
        for(int i=0;i<result.Length;i++)
        {
            result[i] = content
                          .GetType()
                          .GetMethod("Load")
                          .MakeGenericMethod(resources[i].Key)
                          .Invoke(content, new object[] { resources[i].Value });
        }
        return result;
    }
    
