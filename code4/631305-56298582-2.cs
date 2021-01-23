        public SomethingOrOther(ISqlFunctions sqlFunctions)
        {
            var convertError = models
                .Where(x => sqlFunctions.StringConvert((decimal?)(x.convert ?? 0)) == "0")
                .Any();
        }
