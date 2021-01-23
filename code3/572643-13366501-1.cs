    public class StudentsVM
    {
    public IEnumerable<Student_A> Student_A { get; set; }
    public IEnumerable<Student_B> Student_B { get; set; }
    }
    
    var vm = new StudentsVM;
    vm.Student_A = stud.Student_A.Where(...);
    vm.Student_B = stud.STudent_B.Where(...);
    
    ViewData.Model = vm;
