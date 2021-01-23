    [Serializable]
    public struct SerializableThickness : ISerializable
    {
        public Thickness Data;
        public SerializableThickness(Thickness t)
        {
            Data = t;
        }
        #region ISerializable
        private const string LeftField = "LeftField";
        private const string TopField = "TopField";
        private const string RightField = "RightField";
        private const string BottomField = "BottomField";
        private SerializableThickness(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            var enumerator = info.GetEnumerator();
            bool[] found = { false, false, false, false };
            double[] values = new double[4];
            while (enumerator.MoveNext() && !found.All(x => x))
            {
                switch (enumerator.Name)
                {
                    case LeftField:
                        found[0] = true;
                        values[0] = (double)enumerator.Value;
                    break;
                    case TopField:
                        found[1] = true;
                        values[1] = (double)enumerator.Value;
                    break;
                    case RightField:
                        found[2] = true;
                        values[2] = (double)enumerator.Value;
                    break;
                    case BottomField:
                        found[3] = true;
                        values[3] = (double)enumerator.Value;
                    break;
                }
            }
            if (!found.All(x => x))
                throw new SerializationException("Missing serializable members");
            Data = new Thickness(values[0], values[1], values[2], values[3]);
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(LeftField, Data.Left);
            info.AddValue(TopField, Data.Top);
            info.AddValue(RightField, Data.Right);
            info.AddValue(BottomField, Data.Bottom);
        }
        #endregion
    }
