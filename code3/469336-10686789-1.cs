            [WebGet(UriTemplate = "GetWarrant?id={s}&user={user}")]
        public WarrantBook GetWarrant(string s, string user)
        {
            int id;
            if (int.TryParse(s, out id))
            {
                EditableWarrantBook model = SessionWarrantBook.One(p => p.Id == id);
                model.CheckedOutBy = user; // need to add checkout code
                WarrantBook jsonModel = new WarrantBook();
                model.CopyProperties(jsonModel);
                return jsonModel;
            }
            return new WarrantBook();
        }
    
