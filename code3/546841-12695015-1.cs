        protected DateRange(SerializationInfo info, StreamingContext context) {
            if (info == null)
                throw new ArgumentNullException("info");
            var foundPast = (bool) info.GetValue("thePast", typeof (bool));
            if (foundPast)
                Start = DatePoint.Past;
            var foundFuture = (bool) info.GetValue("theFuture", typeof (bool));
            if (foundFuture)
                End = DatePoint.Future;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("thePast", Start.Equals(DatePoint.Past), typeof(bool));
            info.AddValue("theFuture", End.Equals(DatePoint.Future), typeof(bool));
        }
