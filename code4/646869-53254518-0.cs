       // GET: api/Tareas
        [HttpGet]
        public IEnumerable<Tarea> GetTareas()
        {
            var result = _context.Tareas
                .Include(p => p.SubTareas)
                .Select(p => SortInclude(p));
            return result;
        }
    
        private Tarea SortInclude(Tarea p)
        {
            p.SubTareas = (p.SubTareas as HashSet<SubTarea>)?
                .OrderBy(s => s.Position)
                .ToHashSet<SubTarea>();
            return p;
        }
