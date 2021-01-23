    interface IItemFieldVisitor {
        void VisitString(string val);
        void VisitMyItem(MyItem val);
        void VisitList(IList<MyItem> val);
    }
    interface IItemField {
        string Name {get;set;}
        void Accept(IItemFieldVisitor visitor);
    }
    class StringItemField : IItemField {
        public string Name {get;set;}
        private string val;
        public void Accept(IItemFieldVisitor visitor) {
            visitor.VisitString(val);
        }
    }
    class MyItemItemField : IItemField {
        public string Name {get;set;}
        private MyItem val;
        public void Accept(IItemFieldVisitor visitor) {
            visitor.VisitMyItem(val);
        }
    }
    class MyItemListItemField : IItemField {
        public string Name {get;set;}
        private IList<MyItem> val;
        public void Accept(IItemFieldVisitor visitor) {
            visitor.VisitList(val);
        }
    }
