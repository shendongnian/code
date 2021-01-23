    private static void AddNewPriceSettings(PRICE_SETTING priceSettingsInfo)
    {
       PRICE_SETTING priceSetting = new PRICE_SETTING();
       //
       priceSetting.Prop1 = priceSettingsInfo.Prop1;
       priceSetting.Prop2 = priceSettingsInfo.Prop2;
       priceSetting.Prop3 = priceSettingsInfo.Prop3;
       // ...
       DataContext.CommonUsers.PRICE_SETTINGs.InsertOnSubmit(priceSetting );          
       DataContext.CommonUsers.SubmitChanges();
    }
