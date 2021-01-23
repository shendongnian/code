    public override void Install(IDictionary stateSaver)
    {
         base.Install(stateSaver);
       
         string the_commandline_property_value = Context.Parameters["MYPROPERTY"].ToString();
    }
