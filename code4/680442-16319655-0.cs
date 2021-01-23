     Context.SubmitChanges(Result =>
             {
                 if (Result.HasError)
                     {
                     CallBack(Result.Error.ToString());
                     }
                 else
                     {
                     CallBack("Done");
                     }
             }, null);
