    public static CustomFindingService FindingService(string requestType){ // edit
    CustomFindingService findingService;
    log.InfoFormat("Connect to Ebay: START");
    
    findingService = new CustomFindingService("XXXXXX-XXXX-XXXXX-XXXXX-XXXXX", requestType); // EDIT
    findingService.UseDefaultCredentials = true;
    
    log.InfoFormat("Connect to Ebay: SUCCESS");
    return findingService;
       }
    
    var fcir = new FindCompletedItemsRequest {keywords = "5mp", categoryId =new string[] {"31388"}}; // 31388 is digital cameras
    var l = FindingService(fcir.GetType().Name).findCompletedItems(fcir); // Edit
    // Or since you know the Name already just skip the whole get type thing and pass it in directly.
