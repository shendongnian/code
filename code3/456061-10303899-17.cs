    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace FetchTest
    {
        public class MasterEnt
        {
            private Int32? id;
            /// <summary>
            /// Entity key
            /// </summary>
            public virtual Int32? Id
            {
                get { return id; }
                set { id = value; }
            }
    
            private String description;
            /// <summary>
            /// Description
            /// </summary>
            public virtual String Description
            {
                get { return description; }
                set { description = value; }
            }
    
            private ICollection<DetailEnt> detailEntList;
            /// <summary>
            /// <see cref="RIDetailEnt"/> one-to-many relationship.
            /// </summary>
            public virtual ICollection<DetailEnt> DetailEntList
            {
                get { return detailEntList; }
                set { detailEntList = value; }
            }
        }
    }
