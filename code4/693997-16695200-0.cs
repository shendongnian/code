    private void button1_Click(object sender, EventArgs e)
    {
        Dictionary<string, int> students = new Dictionary<string, int>();
        students.Add("Peter", 67);
        students.Add("Brayan", 76);
        students.Add("Lincoln", 56);
        students.Add("Jack", 65);
        students.Add("Mahone", "no score");
        students.Add("Kevin", 64);
        foreach (var student in students)
        {
            listBox1.Items.Add(student.Value);
        }
    }
