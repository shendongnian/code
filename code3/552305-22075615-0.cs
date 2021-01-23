    public class MyMeasureAction : MeasureAction
    {
        public void Execute()
        {
            OnTargetChanged(null, (Map)TargetObject);
            Invoke(null);
        }
    }
...
    var mymeasure = new MyMeasureAction();
    mymeasure.TargetObject = MyMap;
    mymeasure.xxxx = xxxx
    ....
    mymeasure.Execute();
