        public delegate void MyPersonalizedUCEventHandler(string sampleParam);
        public event MyPersonalizedUCEventHandler MyPersonalizedUCEvent;
        public void RaiseMyEvent()
        {
			// Your logic
            if (MyPersonalizedUCEvent != null)
            {
                MyPersonalizedUCEvent("sample parameter");
            }
        }
