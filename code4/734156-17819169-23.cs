    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirm(int id)
    {
        var subscription = _context.Subscriptions.Find(id);
        if (subscription != null)
            _context.Subscriptions.Remove(subscription);
            
        return RedirectToAction("Index");
    }
