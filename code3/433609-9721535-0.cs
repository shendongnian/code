    //First put the namespace of your target class in using block
    protected void btnTarget_OnClick(object sender, EventArges e)
    {
        //Target.NameSpace.TargetClass target = new Target.NameSpace.TargetClass(); // without using namespace in using blcok
        TargetClass target = new TargetClass(); // you can use direct Namespece here
        target.TargetMethod();
    }
