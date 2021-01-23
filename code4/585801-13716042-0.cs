	string[][] student_details = new string[STUDENTS][];
	string[][][] subject_details = new string[STUDENTS][][];
	string[][] result_details = new string[STUDENTS][];
	for (int a = 0; a < STUDENTS; a++)
	{
		student_details[a] = new string[STUDENTS * 2];
		subject_details[a] = new string[SUBJECTS][];
		Console.WriteLine("Enter Student {0} {1}:", a + 1, "Name");
		student_details[a][0] = Console.ReadLine();
		Console.WriteLine("Enter Student {0} {1}:", a + 1, "Roll-No");
		student_details[a][1] = Console.ReadLine();
		for (int c = 0; c < SUBJECTS; c++)
		{
			subject_details[a][c] = new string[SUBJECTS * 2];
			Console.WriteLine("Enter Name for Subject {0}", c + 1);
			subject_details[a][c][0] = Console.ReadLine();
			Console.WriteLine("Enter Marks for {0}", subject_details[a][c][0]);
			subject_details[a][c][1] = Console.ReadLine();
		}
	}
	for (int a = 0; a < STUDENTS; a++)
	{
		Console.Write(student_details[a][0] + "\t");
		Console.Write(student_details[a][1] + "\t");
		for (int c = 0; c < SUBJECTS; c++)
		{
			Console.Write(subject_details[a][c][0] + "\t");
			Console.Write(subject_details[a][c][1] + "\t");
		}
	}
