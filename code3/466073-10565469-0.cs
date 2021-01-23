    Select TOP 30 *
    From Mails As M
    Where Exists	(
    				Select 1
    				From MailAssignments As MA1
    				Where MA1.msgid = M.msgid
    					And MA1.forTeam = 'TEAM01'
    					And ( MA1.notForTeam Is Null Or MA1.notForTeam <>'TEAM01' )
    					And ( MA1.processedByTeam Is Null Or MA1.processedByTeam <> 'TEAM01' )
    				)
    Order By M.sortingTime Desc
