        public class IssuerRecord
        {
            public string PropA { get; set; }
            public IList<IssuerRecord> Subrecords { get; set; }
        }
        public class ImmutableIssuerRecord
        {
            public ImmutableIssuerRecord(IssuerRecord record)
            {
                PropA = record.PropA;
                Subrecords = record.Subrecords.Select(r => new ImmutableIssuerRecord(r));
            }
            public string PropA { get; private set; }
            // lacks Count and this[int] but it's IReadOnlyList<T> is coming in 4.5.
            public IEnumerable<ImmutableIssuerRecord> Subrecords { get; private set; }
            // you may want to get a mutable copy again at some point.
            public IssuerRecord GetMutableCopy()
            {
                var copy = new IssuerRecord
                               {
                                   PropA = PropA,
                                   Subrecords = new List<IssuerRecord>(Subrecords.Select(r => r.GetMutableCopy()))
                               };
                return copy;
            }
        }
