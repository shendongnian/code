        public ICollection<Paragraph> Options
        {
            get
            {
                if (Section != null)
                {
                    return Section.Paragraphs
                        .Where(p => p.Major == Major && p.Option != Option)
                        .ToList();
                }
                else
                {
                    return new List<Paragraph>();
                }
            }
        }
