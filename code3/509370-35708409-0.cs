    // eg: /reviews
    [Route(“reviews”)]
    public ActionResult Index() { … }
    // eg: /reviews/5
    [Route(“reviews/{reviewId}”)]
    public ActionResult Show(int reviewId) { … }
    // eg: /reviews/5/edit
    [Route(“reviews/{reviewId}/edit”)]
    public ActionResult Edit(int reviewId) { … }
