    [HttpPost]
    [Route("[action]")]
    public IActionResult PostCustomerAndOrder
    ([FromBody]CustomerOrder obj)
    {
    }
