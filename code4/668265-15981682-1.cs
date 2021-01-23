    db.Courses.Select(x => new CourseDto {
        Id = x.Id,
        Lab = x.Lab,
        Modules = x.Modules.Where(m => !m.IsDeleted).Select( m => new ModuleDto {
            Moudle = m,
            Chapters = x.Chapters.Where(c => c.IsDeleted)
        }
    }).Single(x => x.Id == id);
