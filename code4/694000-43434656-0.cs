            Hashtable student = new Hashtable();
            student.Add("Peter", 67);
            student.Add("Brayan", 76);
            student.Add("Lincoln", 56);
            student.Add("Jack", 65);
            student.Add("Mahone", "no score");
            student.Add("Kevin", 64);
            ICollection key = student.Keys;
            foreach (string k in key)
            {
                listBox1.Items.Add("Student: " + k + ", Score: " + student[k]);
            }
        }
