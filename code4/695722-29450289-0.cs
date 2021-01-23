    class DieGameAction : IGameAction {
    
        IList<object> gameObjectList;
    
        public DieGameAction(IList<object> objectList) {
            gameObjectList = objectList; 
        }
    }
