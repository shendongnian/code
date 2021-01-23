    public class ParentClass
    {
      public Parent(int feature1)
      {
        mFeature1 = feature1;
      }
    }
    
    public class ChildClass : ParentClass
    {
      public ChildClass(int feature1, int feature2) : base(feature1)
      {
        mFeature2 = feature2;
      }
    }
    
    ...
    ...
    ChildClass cc = new ChildClass(10, 20);
    ParentClass pc = (ParentClass)cc; // pc still is of type ChildClass
    ParentClass ccAsParent = new ParentClass(cc.Feature1); //ccAsParent is of type ParentClass
    ...
    ...
