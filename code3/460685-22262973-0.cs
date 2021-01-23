            const string nameTrim = "PaymentProcessor"; 
            var type = typeof(IPaymentProcessor);
            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(x => type.IsAssignableFrom(x) && x.IsClass).ToList()
                .ForEach(t =>
                {
                    var name = t.Name.ToLower();
                    if (name.EndsWith(nameTrim))
                        name = name.Substring(0, name.Length - nameTrim.Length);
                    TinyIoCContainer.Current.Register(type, t, name);
                });
