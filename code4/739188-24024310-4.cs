    public async Task<ActionResult> RenderImage(int id)
    {
        Item item = await db.Items.FindAsync(id);
        byte[] photoBack = item.InternalImage;
        return File(photoBack, "image/png");
    }
