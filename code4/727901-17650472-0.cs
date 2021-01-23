    -- Student Statement
    SELECT
                 S.StudentID,
                 S.StudentName
        FROM
                 StudentExam SE
            JOIN
                Student S
                    ON S.StudentID = SE.StudentID;
    -- Exam Statement
    SELECT
                SE.StudentID,
                E.ExamID,
                E.ExamName,
                SE.Mark 
        FROM
                StudentExam SE
            JOIN
                Exam E
                    ON E.ExamID = SE.ExamID;
