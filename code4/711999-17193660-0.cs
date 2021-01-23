    class MyAbstractObject
        class MyAbstractUIObject : MyAbstractObject
            class MyAbstractTable : MyAbstractUIObject
    interface IMyAbstractTableBehaviour { void Perform(); }
        class MyAbstractTablePageableBehaviour : IMyAbstractTableBehaviour
        class MyAbstractTableScrollableBehaviour : IMyAbstractTableBehaviour
        class MyAbstractTableStateableBehaviour : IMyAbstractTableBehaviour
