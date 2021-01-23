            using (var context = new DocumentAssignment())
            {
                var assessor = context.Assessors.Find(1);
                var document = context.Documents.Find(1);
                assessor.Documents.Add(document);
                context.SaveChanges();
            }
