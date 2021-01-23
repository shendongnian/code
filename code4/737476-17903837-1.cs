    public class Program {
        public void Main() {
            Dictionary<int, Meeting> meetingDictionary 
                 = new Dictionary<int, Meeting>(); //`int` on the left will be the key, and `Meeting` on the right is the value
                //int represents a unique Id of the meet event.
                //To add a new meeting:
                var date = new DateTime(2013, 7, 21); //date representor of the meet
                var meetingA = new Meeting("Obamba Blackinson", date); //object to hold this data.
                meetingDictionary.Add(1, meetingA); //note that Id can change to anything you wish, for example a string of the person's name.
                //How to pull it out of dictionary:
                var meetWithObamba = meetingDictionary[1];
                //**do w/e with the meet**. any modifications of meetWithObamba will edit the item in the dictionary too.
            }
        }
        public class Meeting {
            string PersonName;
            DateTime MeetingDate;
            public Meeting(string name, DateTime date) {
                PersonName = name;
                MeetingDate = date;
            }
        }
    }
