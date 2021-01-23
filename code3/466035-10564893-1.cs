    private List<Steering> steeringValues;
    public IdleSteering(List<Steering> userSteering)
    {
        steeringValues = userSteering;
    }
 
    //we can now use LINQ to find any particular steering value.
    int braking = steeringValues.SingleOrDefault(x=>x.SteerType==Random).Amount;
