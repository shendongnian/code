    [HttpPost]
    public ActionResult TaskProgress(Guid taskId)
    {
        var isTaskRunning = MemoryCache.Default.Contains(taskId.ToString());
        return Json(new { status = isTaskRunning });
    }
