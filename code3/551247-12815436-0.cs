        public Java.Lang.Object[] GetSections()
        {            
            Java.Lang.String[] tmpObjCollection = new Java.Lang.String[this._sections.Count];
            for (int i = 0; i < this._sections.Count; i++)
            {
                tmpObjCollection[i] = new Java.Lang.String(this._sections[i]);
            }
            return tmpObjCollection;
        }
