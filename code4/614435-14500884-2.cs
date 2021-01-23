        public event Action<String> MyPersonalizedUCEvent;
        public void RaiseMyEvent()
        {
            // Your logic
            if (MyPersonalizedUCEvent != null)
            {
                MyPersonalizedUCEvent("sample parameter");
            }
        }
More about the Action delegate can be found in this [link][1].
