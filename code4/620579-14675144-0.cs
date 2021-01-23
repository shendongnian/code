    class MyObject {
        MyOtherObject otherObj;
        public MyObject(IMyFirstDependency dependency, IMySecondDependency dependencyTwo) {
            otherObj = new MyOtherObject(dependencyTwo);
        }
    }
