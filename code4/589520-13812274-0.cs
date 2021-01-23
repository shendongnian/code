    public async Task<ActionResult> GizmosAsync()
    {
        var gizmoService = new GizmoService();
        return View("Gizmos", await gizmoService.GetGizmosAsync());
    }
