    public async Task<IActionResult> DeleteAll()
    {
        var list = await _context.YourClass.ToListAsync();
        _context.YourClass.RemoveRange(list);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
