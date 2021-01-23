    var rosterTeacher = ctx.SpecialProject
        .Where(sp => sp.caseID == cID && sp.isTeacher)
        .Join(ctx.Teachers, m => m.teacherID, p => p.teacherID,
              (sp, m) => new SpecProjRosterView
                            {
                                RosterEmail = m.memEMail,
                                RosterName = (m.memLastName + ", " + m.memFirstName),
                                RosterVerified = sp.caseRosterIsVerified
                            }).ToList();
    
    var rosterStudents = ctx.SpecialProject
        .Where(c => c.caseID == cID && c.isStudents)
        .Join(ctx.CaseStudents, u => u.studentID, p => p.studentID,
              (sp, m) => new SpecProjRosterView
                            {
                                RosterEmail = m.caseStudentsEMail,
                                RosterName = (m.caseStudentsLastName + ", " + m.caseStudentsFirstName),
                                RosterVerified = sp.caseRosterIsVerified
                            }).ToList();
    
    return rosterTeacher.Union(rosterStudents).ToList();
