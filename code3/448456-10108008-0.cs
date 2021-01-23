    public ViewResult ViewThread(int threadId, int page = 1)
    {
        var thread = _forumService.GetThread(threadId, page);
        thread.Posts = new PaginatedList(thread.Post, page);
        var viewModel = Mapper.Map<Thread, ThreadView>(thread);
        return View(viewModel);
    } 
