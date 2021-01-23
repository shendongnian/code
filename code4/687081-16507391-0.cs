		Articles(idArticle, nameArticle, statusArticle, idSubject)
		Subjects(idSubject,nameSubject)
		Articles firstArticle = db.Articles.FirstOrDefault(u => u.statusArticle == false);
		if (firstArticle != null)
		{
			textBox1.Text = firstArticle.nameArticle;
			Subject subject = db.Subjects.FirstOrDefault(s => s.idSubject == firstArticle.idSubject);
			textBox2.Text = (subject != null) ? subject.nameSubject : string.Empty;
		} 
