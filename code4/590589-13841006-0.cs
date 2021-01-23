    quizresult = JsonConvert.DeserializeObject<Quiz>(args.Message,
                     new JsonSerializerSettings
                     {
                         Error = delegate(object sender1, ErrorEventArgs args1)
                         {
                             errors.Add(args1.ErrorContext.Error.Message);
                             args1.ErrorContext.Handled = true;
                         }
                     });
