    public class RequestorMenuItems : MenuItemsPolicy{
        public override List<MenuItem> GetMenuItems(){
            return new List<MenuItem>(){
                CreateMenuItem("Request A New Course", "~/Courses/RequestNewCourse.aspx"),
                CreateMenuItem("View My New Course Requests", "~/Courses/ViewMyCourseRquests.aspx")
            };
        }
    }
