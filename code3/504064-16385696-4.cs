        #region IRestService Members
        public string XMLData(string id)
        {
            return "You Request Porduct" + ":"+id;
        }
        public string JSONData(string id)
        {
            return "Yor Request Product" +":"+ id;
        }
        #endregion
    }
