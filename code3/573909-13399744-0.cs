    static string MemberName([CallerMemberName] string name = null) {
        return name;
    }
    int MyProperty {
        set {
            Console.WriteLine(MemberName());
        }
    }
