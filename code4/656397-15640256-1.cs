    public ActionResult Save()
    {
        Customer customer=this.currentCustomerSession;
    customer.OnCityInfoChanged += new Action<CityInfo>( (cityInfo) => {//Do Something with New CityInfo});
        if(TryUpdateModel<Customer>(customer)){
           UpdateModel<Customer>(customer)
        }
        if(customer.IsCustomerNameModified ){
            //I am able to detect whether the customerName value has been changed in the frontend.
        }
        if(customer.IsCityModified){
            //I am not able to detect whether the city value has been changed in the frontend.
        }
    }
