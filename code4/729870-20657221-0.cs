    [System.Web.Http.HttpPost]
    public string PostCustomer(string customerJsonString)
        {
            CustomerDetailDto customer = JsonConvert.DeserializeObject<CustomerDetailDto>(customerJsonString);
            bool res = _customerService.SaveOrUpdateCustomer(customer);
        if (res)
                  {
            ....
          }
    return something;
            }
