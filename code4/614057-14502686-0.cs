            public void getAttachments(long lSession, CDefect def)
        {
            ttsoapcgi cgiengine = new ttsoapcgi();
            // Lock the defect for edit.
            CDefect lockedDefect = cgiengine.editDefect(lSession, def.recordid, "", false);
            string attachment = "c:\\TEST\\TEST_PDF.PDF";
            CFileAttachment file = new CFileAttachment();
            file.mpFileData = File.ReadAllBytes(attachment);
            file.mstrFileName = Path.GetFileName(attachment);
            CReportedByRecord reprec = lockedDefect.reportedbylist[0];
            CFileAttachment[] afile = reprec.attachmentlist;
                if (afile == null)
                {
                    lockedDefect.reportedbylist[0].attachmentlist = new CFileAttachment[1];
                    lockedDefect.reportedbylist[0].attachmentlist[0] = file;
                }
                // Save our changes.
                cgiengine.saveDefect(lSession, lockedDefect);
        }
