            ((IObjectContextAdapter)this).ObjectContext.MetadataWorkspace.LoadFromAssembly(typeof(ResultObject).Assembly);
    
            var Param = parameter!= null ?
                new ObjectParameter("Column", parameter) :
                new ObjectParameter("Column", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ResultObject>("MyStoredProcedure", Param);
        }
