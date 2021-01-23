    public static IEnumerable<Document> GetAssignedDocumentList(int UserID)
        {
            using (var context = new DocumentAssignment())
            {
                return context.Documents.Where(d => d.Assessors.Any(a => a.AssessorID == UserID));
            }
        }
