        public interface IPageHistoryBuilder
        {
            PageHistory Build(Page page);
        }
        public class PageHistoryBuilder : IPageHistoryBuilder
        {
            public PageHistory Build(Page page)
            {
                return new PageHistory
                {
                    // copy ALL the props here
                }
            }
        }
