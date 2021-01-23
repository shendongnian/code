    [Route("/reqstars")]
    public class Reqstar {}
    
    [Route("/reqstars", "GET")]
    public class AllReqstars {}
    
    [Route("/reqstars/{Id}", "GET")]
    public class GetReqstar {}
    
    [Route("/reqstars/{Id}/{Field}")]
    public class ViewReqstar {}
    
    [Route("/reqstars/{Id}/delete")]
    public class DeleteReqstar {}
    
    [Route("/reqstars/{Id}", "PATCH")]
    public class UpdateReqstar {}
    
    [Route("/reqstars/reset")]
    public class ResetReqstar {}
    
    [Route("/reqstars/search")]
    [Route("/reqstars/aged/{Age}")]
    public class SearchReqstars {}
