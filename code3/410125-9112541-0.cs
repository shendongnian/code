        public new CountryIso Cast(String obj)
        {
            int index;
            return Int32.TryParse(obj, out index) ? InstanceDict[index] : null;
        }
