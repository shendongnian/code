     using System;
     using System.Collections.Generic;
     using System.Linq;
     using Opit.Rogatus.DomainObjects;
     namespace MetaDataPortal.Models
     {
	public class AnswerScheme : BaseModel
	{
		public string Name { get; set; }
		public bool IsMissing { get; set; }
		public List<AnswerDisplayItem> Answers { get; set; }
		public AnswerScheme()
		{
			Answers = new List<AnswerDisplayItem>();
		}
		public AnswerScheme(CodeList codeList, bool isMissing) : this()
		{
			Id = codeList.Id;
			Name = codeList.Name;
			IsMissing = isMissing;
			foreach (Code code in codeList.Codes.Where(code => code.Category.IsMissing == isMissing))
			{
				Answers.Add(new AnswerDisplayItem(code));
			}
		}
          }
        }
