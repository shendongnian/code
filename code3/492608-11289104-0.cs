    [KnownType("GetKnownType")]
    public class Section
    {
        static Type[] GetKnownType()
        {
            return new[]
            {
                Type.GetType("Project.Format.A.DataSectionFormatA, Project.Format.A")
            };
        }
    }
