    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Whatever.Domain.Timing {
        public class Period {
            public DateTime StartDateTime {get; private set;}
            public DateTime EndDateTime {get; private set;}
    
            public Period(DateTime StartDateTime, DateTime EndDateTime) {
                if (StartDateTime > EndDateTime)
                    throw new InvalidPeriodException("End DateTime Must Be Greater Than Start DateTime!");
                this.StartDateTime = StartDateTime;
                this.EndDateTime = EndDateTime;
            }
            
    
            public bool Overlaps(Period anotherPeriod){
                return (this.StartDateTime < anotherPeriod.EndDateTime && anotherPeriod.StartDateTime < this.EndDateTime)
            }
    
            public TimeSpan GetDuration(){
                return EndDateTime - StartDateTime;
            }
    
        }
        
        public class InvalidPeriodException : Exception {
            public InvalidPeriodException(string Message) : base(Message) { }    
        }
    }
