    namespace App.Domain.Model
    {
        public class Tuple
        {
            public IEnumerable<photoBlog.Models.Gallery> Gallery{ get; set; }
            public IEnumerable<photoBlog.Models.Post> Post{ get; set; }
        }
    }
