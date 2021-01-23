    [Serializable]
    class MySessionData{
        public int ID;
        public IEnumerable<int> RelatedIDs; //This can be an issue
    }
